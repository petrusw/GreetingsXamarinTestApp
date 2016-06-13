using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace GreetingsXamarinTestApp
{
    public class BasicCalculator : ContentPage
    {
        private Boolean devide = false;
        private Boolean times = false;
        private Boolean minus = false;
        private Boolean plus = false;
        Decimal firstNumber = 0;
        Decimal secondNumber = 0;
        Button enterButton;
        Button[] numberButtons = new Button[10];
        Button[] signButtons = new Button[4];
        string s = "You can not devide by 0!";
        Label titleLabel = new Label
            {
                Text = "Basic Calculator",
                TextColor = Color.Fuchsia,
                BackgroundColor = Color.Gray,
                FontSize =25,
                HorizontalTextAlignment=TextAlignment.Center
            };
            Label resultLabel = new Label
            {
                Text="0",
                HorizontalTextAlignment = TextAlignment.End,
                BackgroundColor=Color.Black,
                TextColor = Color.White,
                FontSize = 35
                
            };
        public BasicCalculator()
        {

            this.Padding = new Thickness(0, 20, 0, 0);
            Button pointButton = new Button { Text = "." };
            signButtons[0] = new Button { Text = "+" };
            signButtons[1] = new Button { Text = "-" };
            signButtons[2] = new Button { Text = "*" };
            signButtons[3] = new Button { Text = "/" };
            signButtons[0].Clicked += OnPlusButtonClicked;
            signButtons[1].Clicked += OnMinusButtonClicked;
            signButtons[2].Clicked += OnTimesButtonClicked;
            signButtons[3].Clicked += OnDevideButtonClicked;
            pointButton.Clicked += OnPointButtonClicked;
            enterButton = new Button
            {
                Text="=",
                BackgroundColor = Color.Lime,
                TextColor = Color.Black
            };
            for (var i = 0; i<10;i++)
            {
                numberButtons[i] = new Button { Text = i.ToString() };
                numberButtons[i].Clicked += OnNumericButtonClicked;

            };
            Button backButton = new Button { Text = "<="};
            Button reset = new Button { Text = "C" };
            backButton.Clicked += OnBackButtonClicked;
            StackLayout firstRow = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,

                Children =
                {
                    numberButtons[7],
                    numberButtons[8],
                    numberButtons[9],
                    signButtons[0],
                    backButton
                }
            };
            StackLayout secondRow =   new StackLayout
            {
                Orientation = StackOrientation.Horizontal,

                Children =
                {
                    numberButtons[4],
                    numberButtons[5],
                    numberButtons[6],
                    signButtons[1]
                }
            };
            StackLayout thirdRow = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,

                Children =
                {
                    numberButtons[1],
                    numberButtons[2],
                    numberButtons[3],
                    signButtons[2],
                    reset
                }
            };
            StackLayout forthRow = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    numberButtons[0],
                    pointButton,
                    enterButton,
                    signButtons[3]
                }
            };
            reset.Clicked += ONResetButtonClicked;
            enterButton.Clicked += OnEnterButtonClicked;
            Content = new StackLayout
            {
                Children = {
                    titleLabel,
                    resultLabel,
                    new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        VerticalOptions=   LayoutOptions.Center,
                        HorizontalOptions=LayoutOptions.Center,
                        Children =
                        {
                           firstRow,
                           secondRow,
                           thirdRow,
                           forthRow,
                          

                        }

                    },


                },
                
            };
            App app = Application.Current as App;
            resultLabel.Text = app.ResultLabelText;

        }

        private void ONResetButtonClicked(object sender, EventArgs e)
        {
            resultLabel.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            App app = Application.Current as App;
            app.ResultLabelText = resultLabel.Text;
            enterButton.IsEnabled = true;
        }
        
        private void OnDevideButtonClicked(object sender, EventArgs e)
        {
            if(resultLabel.Text != "0" && devide == false)
            {
                firstNumber = Convert.ToDecimal(resultLabel.Text);
                devide = true;
                resultLabel.Text = "0";
            }
            App app = Application.Current as App;
            app.ResultLabelText = resultLabel.Text;
        }

        private void OnTimesButtonClicked(object sender, EventArgs e)
        {
            if (times == false)
            {
                firstNumber = Convert.ToDecimal(resultLabel.Text);
                times = true;
                resultLabel.Text = "0";
            }
            App app = Application.Current as App;
            app.ResultLabelText = resultLabel.Text;
        }

        private void OnMinusButtonClicked(object sender, EventArgs e)
        {
            if (minus == false)
            {
                firstNumber = Convert.ToDecimal(resultLabel.Text);
                minus = true;
                resultLabel.Text = "0";
            }
            App app = Application.Current as App;
            app.ResultLabelText = resultLabel.Text;
        }

        private void OnPlusButtonClicked(object sender, EventArgs e)
        {
            if(plus==false)
            {
                firstNumber = Convert.ToDecimal(resultLabel.Text);
                plus = true;
                resultLabel.Text = "0";
            }
            App app = Application.Current as App;
            app.ResultLabelText = resultLabel.Text;
        }

        private void OnEnterButtonClicked(object sender, EventArgs e)
        {
            secondNumber = Convert.ToDecimal(resultLabel.Text);
            if (resultLabel.Text.EndsWith(".") != true)
            {

                if (devide)
                {
                    if (secondNumber != 0 || firstNumber != 0)
                    {
                        var tempNumber = firstNumber / secondNumber;
                        resultLabel.Text = tempNumber.ToString();

                        firstNumber = 0;
                        secondNumber = 0;
                    }
                }
                else if (times)
                {
                    secondNumber = Convert.ToDecimal(resultLabel.Text);
                    var tempNumber = firstNumber * secondNumber;
                    resultLabel.Text = tempNumber.ToString();

                    firstNumber = 0;
                    secondNumber = 0;
                }
                else if (minus)
                {
                    secondNumber = Convert.ToDecimal(resultLabel.Text);
                    var tempNumber = firstNumber - secondNumber;
                    resultLabel.Text = tempNumber.ToString();

                    firstNumber = 0;
                    secondNumber = 0;
                }
                else if (plus)
                {
                    secondNumber = Convert.ToDecimal(resultLabel.Text);
                    var tempNumber = firstNumber + secondNumber;
                    resultLabel.Text = tempNumber.ToString();

                    firstNumber = 0;
                    secondNumber = 0;
                }
                devide = false;
                times = false;
                minus = false;
                plus = false;
                App app = Application.Current as App;
                app.ResultLabelText = resultLabel.Text;
            }

        }
        
        private void OnPointButtonClicked(object sender, EventArgs e)
        {
            if(resultLabel.Text.Contains("."))
            {

            }
            else
            {
                if (resultLabel.Text == "0" || resultLabel.Text == s)
                {
                    resultLabel.Text = "0.";
                    enterButton.IsEnabled = true;
                }
                else
                {
                    resultLabel.Text += ".";
                }
            }
            App app = Application.Current as App;
            app.ResultLabelText = resultLabel.Text;
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (resultLabel.Text.Length != 0)
            {
                resultLabel.Text = resultLabel.Text.Substring(0, resultLabel.Text.Length - 1);
                if(resultLabel.Text.Length == 0)
                {
                    resultLabel.Text = "0";
                }
            }
            else
            {
                resultLabel.Text = "0";
            }
            App app = Application.Current as App;
            app.ResultLabelText = resultLabel.Text;
        }

        private void OnNumericButtonClicked(object sender, EventArgs e)
        {
            enterButton.IsEnabled = true;
            Button button = (Button)sender;
            if (resultLabel.Text != "0" && resultLabel.Text != s )
            {
                
                resultLabel.Text += button.Text;
            }
            else
            {
                resultLabel.Text = button.Text;
                if(devide == true && resultLabel.Text == "0")
                {
                    resultLabel.Text = s;
                   enterButton.IsEnabled = false;
                }
            }
            App app = Application.Current as App;
            app.ResultLabelText = resultLabel.Text;
        }

        
    }
}
