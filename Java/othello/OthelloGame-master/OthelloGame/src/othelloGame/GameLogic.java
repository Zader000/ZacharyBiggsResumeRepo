package othelloGame;

import javax.swing.*;

/**
 * @author Joshua Stoddard & Zach Biggs
 *
 */
public class GameLogic {

	/**
	 * Checks to see who won.
	 */
	public static void checkForWin() {
		int numOfPieces = 0;
		JButton[][] buttons = GameBoard.getGameBoardBtnArray(); 
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				if (buttons[i][j].getIcon() != null) {
					numOfPieces++;
				}
			}
		}
		if (numOfPieces == 64) {
			if (TitleAndScore.getDarkScoreCount() > TitleAndScore.getLightScoreCount()) {
				TitleAndScore.setWinner("Dark");
			} else {
				TitleAndScore.setWinner("Light");
			}
			TitleAndScore.getWinnerAndTurnLbl().setText(TitleAndScore.getWinner() + " wins!");
		}
		
	}

	/**
	 * checks to see if the button clicked is a valid move or not.
	 * 
	 * @param turn which player's turn it is ie black or white
	 * @param row  row of the button in the grid
	 * @param col  coumn of the button in the grid
	 * @return
	 */
	public static boolean checkIfValidMove(int turn, int row, int col) {

		JButton[][] buttons = GameBoard.getGameBoardBtnArray();
		boolean result = false;
		Icon oppCol = GameBoard.getBlackOrWhiteImageArray()[0];

		if (turn % 2 == 0) {
			oppCol = GameBoard.getBlackOrWhiteImageArray()[1];
		}
		if (buttons[row][col].getIcon() == null) {

			if (row + 1 < 8 && col + 1 < 8 && buttons[row + 1][col + 1].getIcon() == oppCol) { // right-down
				result = true;
			} else if (row + 1 < 8 && buttons[row + 1][col].getIcon() == oppCol) {// right
				result = true;
			} else if (col + 1 < 8 && buttons[row][col + 1].getIcon() == oppCol) {// down
				result = true;
			} else if (col - 1 > -1 && buttons[row][col - 1].getIcon() == oppCol) {// up
				result = true;
			} else if (row - 1 > -1 && col - 1 > -1 && buttons[row - 1][col - 1].getIcon() == oppCol) {// left-up
				result = true;
			} else if (row - 1 > -1 && buttons[row - 1][col].getIcon() == oppCol) {// left
				result = true;
			} else if (row - 1 > -1 && col + 1 < 8 && buttons[row - 1][col + 1].getIcon() == oppCol) {// left-down
				result = true;
			} else if (row + 1 < 8 && col - 1 > -1 && buttons[row + 1][col - 1].getIcon() == oppCol) {// right-up
				result = true;
			}
		}
		return result;
	}

	/**
	 * Places the current players piece then searches for other pieces that need to
	 * be captured by using the checkDirection method.
	 * 
	 * @param color which color's turn it is.
	 * @param row   row index of the button pressed
	 * @param col   column index of the button pressed.
	 */
	public static void placePiece(Icon color, int row, int col) {

		GameBoard.getGameBoardBtnArray()[row][col].setIcon(color);
		
	 	flipPieces(row, col, color, 0, -1);
	    flipPieces(row, col, color, 0, 1); 
	    flipPieces(row, col, color, 1,0);
	    flipPieces(row, col, color, -1, 0);
	    flipPieces(row, col, color, 1,1);
	    flipPieces(row, col, color, 1,-1);
	    flipPieces(row, col, color, -1,1);
	    flipPieces(row, col, color, -1,-1);
		
	}

	/**
	 * Searches in a given direction for pieces that need to be flipped as a result
	 * from the player's piece placement.
	 * 
	 * @param row    Original row index of the pressed button
	 * @param column Original column index of the pressed button
	 * @param color  Color of the player that just placed a piece.
	 * @param cDir   direction of the column search.
	 * @param rDir   Direction of the row search.
	 */
	public static void flipPieces(int row, int column, Icon color, int cDir, int rDir) {

		JButton[][] buttons = GameBoard.getGameBoardBtnArray();
		int currentR = row + rDir;
		int currentC = column + cDir;
		Icon black = GameBoard.getBlackOrWhiteImageArray()[0];
		Icon white = GameBoard.getBlackOrWhiteImageArray()[1];
		// not out of bounds
		if (currentR == 8 || currentR < 0 || currentC == 8 || currentC < 0) {
			return;
		}
		// is there a piece here
		while (buttons[currentR][currentC].getIcon() == black || buttons[currentR][currentC].getIcon() == white) {
			// we hit our own color
			if (buttons[currentR][currentC].getIcon() == color) {
				// work backwards flipping all the pieces that we identified as valid.
				while (!(row == currentR && column == currentC)) {
					GameBoard.getGameBoardBtnArray()[currentR][currentC].setIcon(color);
					buttons[currentR][currentC].setIcon(color);
					currentR = currentR - rDir;
					currentC = currentC - cDir;
				}
				break;
				// it is the opposite color so move in the given direction
			} else {
				currentR = currentR + rDir;
				currentC = currentC + cDir;
			}
			// make sure we are still in bounds
			if (currentR < 0 || currentC < 0 || currentR == 8 || currentC == 8) {
				break;
			}
		}
	}

}
