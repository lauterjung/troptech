const cells = document.querySelectorAll(".cell");
const gameOverDiv = document.getElementById("game-over");
const winConditions = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
]

var symbol = "O";
var board = ["", "", "", "", "", "", "", "", ""]

function addListeners() {
    for (const cell of cells) {
        cell.addEventListener("click", handleClick, { once: true });
    }
}

function removeListeners() {
    for (const cell of cells) {
        cell.removeEventListener("click", handleClick);
    }
}

function checkWinner() {
    for (let i = 0; i < winConditions.length; i++) {
        slot1 = winConditions[i][0];
        slot2 = winConditions[i][1];
        slot3 = winConditions[i][2];

        if (board[slot1] === board[slot2] && board[slot1] === board[slot3] && board[slot1] !== "") {
            return true;
        }
    }
};

function checkFullBoard() {
    const emptyCell = (element) => element === "";
    return (!board.some(emptyCell));
};

function swapSymbols(symbol) {
    return symbol === "O" ? "X" : "O";
}

const handleClick = (e) => {
    const cell = e.target;
    const classToAdd = (symbol === "O") ? "O" : "X";
    cell.classList.add(classToAdd);

    let position = Number(cell.id.slice(-1));
    board[position] = symbol;

    if (checkWinner()) {
        gameOver(false);
    } else if (checkFullBoard()) {
        gameOver(true);
    }
    symbol = swapSymbols(symbol);
};

function gameOver(tie) {
    removeListeners();
    
    let gameOverMessage = document.getElementById("game-over-message");
    if(tie){
        gameOverMessage.innerText = "Empate!";
    } else {
        gameOverMessage.innerText = `Jogador ${symbol} venceu!`
    }

    gameOverDiv.classList.add("show-game-over");
    const gameOverButton = document.getElementById("play-again-button");
    gameOverButton.addEventListener("click", () => {
        window.location.reload();
    });
}

function startGame() {
    addListeners();
};

startGame()