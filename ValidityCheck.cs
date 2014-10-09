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
    	const int WHITE_KING = 13;
    	const int BLACK_KING = 29;
	    public static bool isLegal(int[] board, int[] piecePositions, int turn)
        {
        	return isCheck(board, piecePositions, turn);
        }
        
        public static bool isCheck(int[] board, int[] piecePositions, int turn)
        {
        	if (turn == 0){
        		int king = piecePositions[WHITE_KING];
        	} else {
        		int king = piecePositions[BLACK_KING];
        	}
        	
        	return true;
        }
    }
}
