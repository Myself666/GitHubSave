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
            labelEnglishMessage.Text = string.Format(GameMessage.English(MessageType.Hello), DictionryStub.WordPairCount);
            labelRussianMessage.Text = string.Format(GameMessage.Russian(MessageType.Hello), DictionryStub.WordPairCount);
            labelPlayer1Name.Visible = false;
            labelPlayer1Points.Visible = false;
            labelPlayer2Name.Visible = false;
            labelPlayer2Points.Visible = false;
            labelTheWord.Visible = false;
            buttonYes.Visible = false;
            panelVariants.Visible = false;
        }
    }
}
