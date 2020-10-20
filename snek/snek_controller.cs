using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vector = snake.model.Vector;

namespace snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int gameWidth = 25; 
        private const int gameHeight = 25;
        private const int foodCount = 100;
        private Vector _direction = new Vector();
        private Vector _snake = new Vector();
        private readonly Random random = new Random();
        private readonly List<Vector> _foodPositions = new List<Vector>();
        
        public MainWindow()
        {
            InitializeComponent();
            InitGame();
        }

        private void DrawPoint(Vector position,Brush brush)
        {
            var shape = new Rectangle
            {
                Fill = brush
            };
            var unitX = gameCanvas.Width / gameWidth;
            var unitY = gameCanvas.Height / gameHeight;
            shape.Width = unitX;
            shape.Height = unitY;

            Canvas.SetLeft(shape, position.X * unitX);
            Canvas.SetTop(shape, position.Y * unitY);

            gameCanvas.Children.Add(shape);
        }

        private Vector GenerateRandomFreePosition()
        {
            Vector generatedPosition;
            do
            {
                generatedPosition = new Vector(random.Next(gameWidth),random.Next(gameHeight));
            }
            while(_snake == generatedPosition || _foodPositions.Any(food => food == generatedPosition));

            return generatedPosition;
        }

        private void RenderSnake()
        {
            DrawPoint(_snake,Brushes.Coral);
        }

        private void InitGame()
        {
            _snake = new Vector(gameWidth / 2, gameHeight / 2);

            for (int i = 0; i < foodCount;i++) {
                _foodPositions.Add(
                GenerateRandomFreePosition()
                );
            }
            RenderState();
        }

        private void RenderState()
        {
            gameCanvas.Children.Clear();
            RenderFood();
            RenderPotion();
            RenderSnake();
        }

        private void RenderPotion()
        {
        
        }

        private void RenderFood()
        {
            foreach (var food in _foodPositions) {
                DrawPoint(food, Brushes.LightGreen);
            }
        }

        private void GameOver()
        {
            InitGame();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            ApplyInputKey(e.Key);
            if (CalculateState())
            {
                RenderState();
            }
            else {
                GameOver();
            }
           
        }

        private void ApplyInputKey(Key PressedKey)
        {
            switch (PressedKey) {
                case Key.Up:
                    _direction = Vector.Up;
                    break;
                case Key.Down:
                    _direction = Vector.Down;
                    break;
                case Key.Left:
                    _direction = Vector.Left;
                    break;
                case Key.Right:
                    _direction = Vector.Right;
                    break;
            }
        }

        private bool CalculateState() {
            _snake = _snake + _direction;

            if (_snake.X < 0 || _snake.X >= gameWidth || _snake.Y < 0 || _snake.Y >= gameHeight)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
