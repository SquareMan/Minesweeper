﻿using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Minesweeper.Controller;

namespace Minesweeper.Model {
    public class GameBoard {
        public delegate void TileDelegate(Tile tileChanged);

        public event TileDelegate OnTileCreated;
        public event TileDelegate OnTileDestroyed;

        public readonly int Width;
        public readonly int Height;
        public readonly int Bombs;

        private Random rand = new Random();

        private int _safeTilesRemaining;

        private readonly Tile[,] _tiles;

        public GameBoard(int width, int height, int bombs) {
            Width = width;
            Height = height;
            Bombs = bombs;
            _tiles = new Tile[width,height];
        }

        public void CreateBoard() {
            _safeTilesRemaining = Width * Height;
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    Tile t = new Tile(new Point(x, y));

                    _tiles[x, y] = t;
                    OnTileCreated?.Invoke(t);
                    t.OnTileRevealed += OnTileRevealed;
                }
            }

            PlaceBombs();
        }

        public void PlaceBombs() {
            for (int i = 0; i < Bombs; i++) {
                Tile tileToCheck = GetTile(rand.Next(Width), rand.Next(Height));

                if (tileToCheck.IsBomb || tileToCheck.IsRevealed) {
                    //Can't place here
                    i--;
                    continue;
                }

                tileToCheck.AddBomb();
                _safeTilesRemaining--;
            }
        }

        public void OnTileRevealed(int numOfBombs) {
            _safeTilesRemaining--;

            if (_safeTilesRemaining == 0) {
                //TODO: WIN
                Debug.WriteLine("Win");
                GameController.Instance.MainMenu();
            }
        }

        public void ClearBoard() {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    OnTileDestroyed?.Invoke(_tiles[x,y]);
                    _tiles[x, y].Destroy();
                    _tiles[x, y] = null;
                }
            }
            OnTileCreated = null;
            OnTileDestroyed = null;
        }

        public Tile GetTile(int x, int y) {
            if (x < 0 || x >= Width || y < 0 || y >= Height) {
                //Requested tile is out of bounds
                return null;
            }

            return _tiles[x, y];
        }
    }
}
