using System.Windows.Forms;

namespace EnglishQuestionGui
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            labelEnglishMessage.Text = string.Format(GameMessage.English(MessageType.Hello), GameStub.WordCount);
            labelRussianMessage.Text = string.Format(GameMessage.Russian(MessageType.Hello), GameStub.WordCount);
            
            labelPlayer1Name.Visible = false;
            labelPlayer1Points.Visible = false;
            
            labelPlayer2Name.Visible = false;
            labelPlayer2Points.Visible = false;
            
            labelTheWord.Visible = false;
            buttonYes.Visible = false;
            panelVariants.Visible = false;

            buttonMultiPlayer.Visible = true;
            buttonSinglePlayer.Visible = true;
        }

        private void buttonSinglePlayer_Click(object sender, System.EventArgs e)
        {
            GameStub.LoadGame();
        }

        private void buttonMultiPlayer_Click(object sender, System.EventArgs e)
        {
            GameStub.LoadGame();
        }
    }
}
