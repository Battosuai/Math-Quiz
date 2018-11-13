using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int add1, add2, timeleft;
        int min1, min2;
        int mul1, mul2;
        int div1, div2;

        public Form1()
        {
            InitializeComponent();

        }

        private void value_ChangeSum(object sender, EventArgs e)
        {
            if (add1 + add2 == sum.Value){
                SystemSounds.Beep.Play();
            }
        }

        private void value_ChangeDiff(object sender, EventArgs e)
        {
            if (min1 - min2 == difference.Value)
            {
                SystemSounds.Beep.Play();
            }
        }

        private void value_ChangeMultiply(object sender, EventArgs e)
        {
            if (mul1 * mul2 == product.Value)
            {
                SystemSounds.Beep.Play();
            }
        }

        private void value_ChangeDivison(object sender, EventArgs e)
        {
            if (div1 / div2 == quotient.Value)
            {
                SystemSounds.Beep.Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You Got All Answer Correct", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeleft > 0)
            {
                if( timeleft == 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
                timeleft = timeleft - 1;
                timeLabel.Text = timeleft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = add1 + add2;
                difference.Value = min1 - min2;
                product.Value = mul1 * mul2;
                quotient.Value = div1 / div2;
                startButton.Enabled = true;
                timeLabel.BackColor = Color.Wheat;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if( answerBox!= null )
            {
                int lenghtOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lenghtOfAnswer);
            }
        }

        public void StartTheQuiz()
        {
            add1 = randomizer.Next(51);
            add2 = randomizer.Next(51);

            plusLeftLabel.Text = add1.ToString();
            plusRightLabel.Text = add2.ToString();

            sum.Value = 0;

            min1 = randomizer.Next(1, 101);
            min2 = randomizer.Next(1, min1);

            minusLeftLabel.Text = min1.ToString();
            minusRightLabel.Text = min2.ToString();

            difference.Value = 0;

            mul1 = randomizer.Next(2, 11);
            mul2 = randomizer.Next(2, 11);

            timesLeftLabel.Text = mul1.ToString();
            timesRightLabel.Text = mul2.ToString();

            product.Value = 0;

            div2 = randomizer.Next(2, 11);
            int tempDiv1 = randomizer.Next(2, 11);
            div1 = div2 * tempDiv1;

            dividedLeftLabel.Text = div1.ToString();
            dividedRightLabel.Text = div2.ToString();

            quotient.Value = 0;

            timeleft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            if( (add1+add2 == sum.Value) && (min1-min2 == difference.Value) && (mul1 * mul2 == product.Value) && (div1 /div2 == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
