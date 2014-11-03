using System;
using System.Collections.Generic;
using System.Text;

//the namespace must be PAT.Lib, the class and method names can be arbitrary
namespace PAT.Lib
{
    /// <summary>
    /// The math library that can be used in your model.
    /// all methods should be declared as public static.
    /// 
    /// The parameters must be of type "int", or "int array"
    /// The number of parameters can be 0 or many
    /// 
    /// The return type can be bool, int or int[] only.
    /// 
    /// The method name will be used directly in your model.
    /// e.g. call(max, 10, 2), call(dominate, 3, 2), call(amax, [1,3,5]),
    /// 
    /// Note: method names are case sensetive
    /// </summary>
    public class Validity
    {
    	const int WHITE_PAWN_1 = 1;
		const int WHITE_PAWN_2 = 2;
		const int WHITE_PAWN_3 = 3;
		const int WHITE_PAWN_4 = 4;
		const int WHITE_PAWN_5 = 5;
		const int WHITE_PAWN_6 = 6;
		const int WHITE_PAWN_7 = 7;
		const int WHITE_PAWN_8 = 8;
		const int WHITE_QUEENS_ROOK = 9;
		const int WHITE_QUEENS_KNIGHT = 10;
		const int WHITE_QUEENS_BISHOP = 11;
		const int WHITE_QUEEN = 12;
		const int WHITE_KING = 13;
		const int WHITE_KINGS_BISHOP = 14;
		const int WHITE_KINGS_KNIGHT = 15;
		const int WHITE_KINGS_ROOK = 16;
		const int BLACK_PAWN_1 = 17;
		const int BLACK_PAWN_2 = 18;
		const int BLACK_PAWN_3 = 19;
		const int BLACK_PAWN_4 = 20;
		const int BLACK_PAWN_5 = 21;
		const int BLACK_PAWN_6 = 22;
		const int BLACK_PAWN_7 = 23;
		const int BLACK_PAWN_8 = 24;
		const int BLACK_QUEENS_ROOK = 25;
		const int BLACK_QUEENS_KNIGHT = 26;
		const int BLACK_QUEENS_BISHOP = 27;
		const int BLACK_QUEEN = 28;
		const int BLACK_KING = 29;
		const int BLACK_KINGS_BISHOP = 30;
		const int BLACK_KINGS_KNIGHT = 31;
		const int BLACK_KINGS_ROOK = 32;
		static readonly int[] WHITE_DIAGONAL = new int[3] {WHITE_QUEENS_BISHOP, WHITE_QUEEN, WHITE_KINGS_BISHOP};
		static readonly int[] BLACK_DIAGONAL = new int[3] {BLACK_QUEENS_BISHOP, BLACK_QUEEN, BLACK_KINGS_BISHOP};
		static readonly int[] WHITE_STRAIGHT = new int[3] {WHITE_QUEENS_ROOK, WHITE_QUEEN, WHITE_KINGS_ROOK};
		static readonly int[] BLACK_STRAIGHT = new int[3] {BLACK_QUEENS_ROOK, BLACK_QUEEN, BLACK_KINGS_ROOK};
		static readonly int[] WHITE_PAWNS = new int[8] {WHITE_PAWN_1, WHITE_PAWN_2, WHITE_PAWN_3, WHITE_PAWN_4, WHITE_PAWN_5, WHITE_PAWN_6, WHITE_PAWN_7, WHITE_PAWN_8};
		static readonly int[] BLACK_PAWNS = new int[8] {BLACK_PAWN_1, BLACK_PAWN_2, BLACK_PAWN_3, BLACK_PAWN_4, BLACK_PAWN_5, BLACK_PAWN_6, BLACK_PAWN_7, BLACK_PAWN_8};
		static readonly int[] WHITE_KNIGHTS = new int[2] {WHITE_QUEENS_KNIGHT, WHITE_KINGS_KNIGHT};
		static readonly int[] BLACK_KNIGHTS = new int[2] {BLACK_QUEENS_KNIGHT, BLACK_KINGS_KNIGHT};
		static readonly int[] WHITE_KINGS = new int[1] {WHITE_KING};
		static readonly int[] BLACK_KINGS = new int[1] {BLACK_KING};
		
	    public static bool isLegal(int turn, int[] board, int kingPositionRank, int kingPositionFile)
        {
        	return !isCheck(turn, board, kingPositionRank, kingPositionFile);
        }
        
        public static bool isCheck(int turn, int[] board, int kingPositionRank, int kingPositionFile)
        {       	
        	return checkDiagonal(turn, board, kingPositionRank, kingPositionFile) ||
				checkStraight(turn, board, kingPositionRank, kingPositionFile) ||
				checkPawn(turn, board, kingPositionRank, kingPositionFile) ||
				checkKnight(turn, board, kingPositionRank, kingPositionFile) ||
				checkKing(turn, board, kingPositionRank, kingPositionFile);
        }
		
		// checks for diagonal attacks in all 4 diagonal directions
		public static bool checkDiagonal(int turn, int[] board, int kingPositionRank, int kingPositionFile)
		{
			// white's turn
			if (turn == 0)
			{
				return checkContinuous(board, kingPositionRank, kingPositionFile, BLACK_DIAGONAL, 3, 1, 1) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, BLACK_DIAGONAL, 3, 1, -1) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, BLACK_DIAGONAL, 3, -1, 1) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, BLACK_DIAGONAL, 3, -1, -1);
			}
			else // black's turn
			{
				return checkContinuous(board, kingPositionRank, kingPositionFile, WHITE_DIAGONAL, 3, 1, 1) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, WHITE_DIAGONAL, 3, 1, -1) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, WHITE_DIAGONAL, 3, -1, 1) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, WHITE_DIAGONAL, 3, -1, -1);
			}
		}
		
		// checks for straight attacks in all 4 directions
		public static bool checkStraight(int turn, int[] board, int kingPositionRank, int kingPositionFile)
		{
			// white's turn
			if (turn == 0)
			{
				return checkContinuous(board, kingPositionRank, kingPositionFile, BLACK_STRAIGHT, 3, 1, 0) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, BLACK_STRAIGHT, 3, -1, 0) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, BLACK_STRAIGHT, 3, 0, 1) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, BLACK_STRAIGHT, 3, 0, -1);
			}
			else // black's turn
			{
				return checkContinuous(board, kingPositionRank, kingPositionFile, WHITE_STRAIGHT, 3, 1, 0) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, WHITE_STRAIGHT, 3, -1, 0) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, WHITE_STRAIGHT, 3, 0, 1) ||
					checkContinuous(board, kingPositionRank, kingPositionFile, WHITE_STRAIGHT, 3, 0, -1);
			}
		}
		
		// checks for pawn attacks
		public static bool checkPawn(int turn, int[] board, int kingPositionRank, int kingPositionFile)
		{
			// white's turn
			if (turn == 0)
			{
				return checkOnce(board, kingPositionRank, kingPositionFile, BLACK_PAWNS, 8, -1, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_PAWNS, 8, -1, -1);
			}
			else // black's turn
			{
				return checkOnce(board, kingPositionRank, kingPositionFile, WHITE_PAWNS, 8, 1, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_PAWNS, 8, 1, -1);
			}
		}
		
		// checks for knight attacks
		public static bool checkKnight(int turn, int[] board, int kingPositionRank, int kingPositionFile)
		{
			// white's turn
			if (turn == 0)
			{
				return checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KNIGHTS, 2, 2, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KNIGHTS, 2, 2, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KNIGHTS, 2, -2, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KNIGHTS, 2, -2, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KNIGHTS, 2, 1, 2) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KNIGHTS, 2, 1, -2) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KNIGHTS, 2, -1, 2) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KNIGHTS, 2, -1, -2);
			}
			else // black's turn
			{
				return checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KNIGHTS, 2, 2, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KNIGHTS, 2, 2, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KNIGHTS, 2, -2, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KNIGHTS, 2, -2, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KNIGHTS, 2, 1, 2) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KNIGHTS, 2, 1, -2) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KNIGHTS, 2, -1, 2) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KNIGHTS, 2, -1, -2);
			}
		}
		
		// checks for king attacks
		public static bool checkKing(int turn, int[] board, int kingPositionRank, int kingPositionFile)
		{
			// white's turn
			if (turn == 0)
			{
				return checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KINGS, 1, 0, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KINGS, 1, 0, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KINGS, 1, -1, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KINGS, 1, -1, 0) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KINGS, 1, -1, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KINGS, 1, 1, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KINGS, 1, 1, 0) ||
					checkOnce(board, kingPositionRank, kingPositionFile, BLACK_KINGS, 1, 1, 1);
			}
			else  // black's turn
			{
				return checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KINGS, 1, 0, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KINGS, 1, 0, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KINGS, 1, -1, 1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KINGS, 1, -1, 0) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KINGS, 1, -1, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KINGS, 1, 1, -1) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KINGS, 1, 1, 0) ||
					checkOnce(board, kingPositionRank, kingPositionFile, WHITE_KINGS, 1, 1, 1);
			}		
		}
		
		// checks for pieces checking the king in a given direction
		public static bool checkContinuous(int[] board, int kingPositionRank, int kingPositionFile, int[] pieceList, int size, int up, int right)
		{
			kingPositionRank += up;
			kingPositionFile += right;
			while (withinBoard(kingPositionRank, kingPositionFile))
			{
				// if the board is not empty
				int location = kingPositionRank * 8 + kingPositionFile;
				if (board[location] != 0)
				{
					for (int i = 0; i < size; i++)
					{
						if (board[location] == pieceList[i])
						{
							return true;
						}
					}					
					return false;
				}
				// if it's empty, move forward
				kingPositionRank += up;
				kingPositionFile += right;				
			}
			
			return false;
		}
		
		// checks for pieces checking the king in a given position
		public static bool checkOnce(int[] board, int kingPositionRank, int kingPositionFile, int[] pieceList, int size, int up, int right)
		{				
			kingPositionRank += up;
			kingPositionFile += right;
			
			// if the board is not empty
			int location = kingPositionRank * 8 + kingPositionFile;
			if (withinBoard(kingPositionRank, kingPositionFile) && board[location] != 0)
			{
				for (int i = 0; i < size; i++)
				{
					if (board[location] == pieceList[i])
						return true;
				}
				
			}

			return false;
		}
		
		// checks whether a given position is inside the board
		public static bool withinBoard(int x, int y)
		{
			return x > -1 && x < 8 && y > -1 && y < 8;
		}
		
    }
}
