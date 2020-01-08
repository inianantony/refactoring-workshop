﻿using System.Collections.Generic;

namespace UglyTrivia
{
    public class GamePlayers
    {
        private readonly List<Player> _gamePlayers = new List<Player>();
        private int _currentPlayerIndex;
        public bool _isGettingOutOfPenaltyBox;

        public GamePlayers()
        {
            _currentPlayerIndex = 0;
        }

        public void AddPlayer(Player player)
        {
            _gamePlayers.Add(player);
        }

        public string CurrentPlayerName => CurrentPlayer.PlayerName;
        public Player CurrentPlayer => _gamePlayers[_currentPlayerIndex];

        public int PlayerCount => _gamePlayers.Count;

        public void MoveToRandomPlace(int roll)
        {
            CurrentPlayer.MoveToPlace(roll);
        }

        public bool CurrentPlayerIsInPenalty => CurrentPlayer.Penalty;

        public int CurrentPlayersPlace => CurrentPlayer.Place;
        public int CurrentPlayerPoints => CurrentPlayer.Point;

        public void MoveToNextPlayer()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex == PlayerCount) _currentPlayerIndex = 0;

        }

        public void AddPointToCurrentPlayer()
        {
            CurrentPlayer.AddPoint();
        }

        public bool DidCurrentPlayerWin()
        {
            return CurrentPlayer.IsWinner;
        }

        public void GivePenaltyToCurrentPlayer()
        {
            CurrentPlayer.SetPenalty();
        }

        public bool CanPlayerAnswer()
        {
            return !_gamePlayers.CurrentPlayerIsInPenalty || _gamePlayers._isGettingOutOfPenaltyBox;
        }
    }
}