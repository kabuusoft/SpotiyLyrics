using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyLyrics.Core.Abstract;

namespace SpotifyLyrics
{
    public partial class MainForm : BaseForm
    {
        private readonly IDownloadManager _downloadManager;
        private readonly ISongNameParser _songNameParser;
        private readonly ISpotifyManager _spotifyManager;

        private bool _isDownloading;
        private string _previousSpotifyWindowTitle = string.Empty;

        public MainForm(ISpotifyManager spotifyManager, IDownloadManager downloadManager, ISongNameParser songNameParser)
        {
            _spotifyManager = spotifyManager;
            _downloadManager = downloadManager;
            _songNameParser = songNameParser;
            InitializeComponent();
        }

        private async void SpotifyWatchDogTimer_Tick(object sender, EventArgs e)
        {
            if (!_isDownloading)
                if (_spotifyManager.IsSpotifyWorking())
                {
                    var currentSpotifyWindowTitle = _spotifyManager.GetSpotifyWindowTitle();

                    // Yeni şarkıya geçilmiş, indirme akışını başlat.
                    if (currentSpotifyWindowTitle != _previousSpotifyWindowTitle)
                    {
                        _previousSpotifyWindowTitle = currentSpotifyWindowTitle;

                        await DoDownloadLyricWithWindowTitle(currentSpotifyWindowTitle);
                    }
                }
        }

        private async Task DoDownloadLyricWithWindowTitle(string currentSpotifyWindowTitle)
        {
            // Todo: cancel current download
            if (_isDownloading) return;

            var artistAndSongInfo = _songNameParser.GetSongNameAndArtistFromWindowTitle(currentSpotifyWindowTitle);

            if (!string.IsNullOrEmpty(artistAndSongInfo.artist) && !string.IsNullOrEmpty(artistAndSongInfo.songName))
            {
                ArtistEdit.Text = artistAndSongInfo.artist;
                SongTitleEdit.Text = artistAndSongInfo.songName;

                await DoDownloadLyric(currentSpotifyWindowTitle, artistAndSongInfo);
            }
            else
            {
                ArtistEdit.Text = string.Empty;
                SongTitleEdit.Text = string.Empty;
            }
        }

        private async Task DoDownloadLyric(string currentSpotifyWindowTitle, (string artist, string songName) artistAndSongInfo, bool forceDownload = false)
        {
            DoDownloadingUiState();
            _isDownloading = true;
            MessageLabel.Text = "Searching for lyric...";
            try
            {
                var lyricContent = await _downloadManager.DownloadLyric(artistAndSongInfo.artist, artistAndSongInfo.songName, currentSpotifyWindowTitle, forceDownload);

                if (string.IsNullOrEmpty(lyricContent.lyric))
                {
                    MessageLabel.Text = "Unable to find lyric.";
                }
                else
                {
                    MessageLabel.Text = $"Lyric source is {lyricContent.source}.";
                }
                LyricBox.Text = lyricContent.lyric;
            }
            finally
            {
                _isDownloading = false;
                DoNormalUiState();
            }
        }

        private async Task DoForceDownload()
        {
            if (_isDownloading) return;

            var artist = ArtistEdit.Text.Trim();
            var song = SongTitleEdit.Text.Trim();
            if (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(song))
            {
                MessageBox.Show("Please enter both artist and song.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_previousSpotifyWindowTitle)) return;

            await DoDownloadLyric(_previousSpotifyWindowTitle, (artist, song), true);
        }

        private void DoDownloadingUiState()
        {
            ArtistEdit.Enabled = false;
            SongTitleEdit.Enabled = false;
            ForceDownloadBtn.Enabled = false;
        }

        private void DoNormalUiState()
        {
            ArtistEdit.Enabled = true;
            SongTitleEdit.Enabled = true;
            ForceDownloadBtn.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetColors();
            SpotifyWatchDogTimer.Enabled = true;
        }

        private async void ForceDownloadBtn_Click(object sender, EventArgs e)
        {
            await DoForceDownload();
        }

        private async void ArtistEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) await DoForceDownload();
        }

        private void SongTitleEdit_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private async void SongTitleEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) await DoForceDownload();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            SettingsMenu.Show(ptLowerLeft);
        }
    }
}