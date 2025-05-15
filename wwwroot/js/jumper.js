const jumper = document.getElementById('jumper');

const TILE_WIDTH = 80;
const TILE_HEIGHT = 70;

let gridCols;
let gridRows;
let validPositions = []; 
let currentRow, currentCol;

const jumperOffsetX = 6; // Adjust horizontal centering of jumper on tile
const jumperOffsetY = 25; // Adjust vertical centering of jumper on tile

function calculateGrid() {
  gridCols = Math.floor(window.innerWidth / TILE_WIDTH);
  gridRows = Math.floor(window.innerHeight / TILE_HEIGHT);
  
  validPositions = [];

  for (let row = 0; row < gridRows; row++) {
    for (let col = 0; col < gridCols; col++) {
      const offsetX = (row % 2 === 0) ? 0 : TILE_WIDTH / 2;
      const x = col * TILE_WIDTH + offsetX;
      const y = row * TILE_HEIGHT;
      validPositions.push({ x, y });
    }
  }
}

// Convert (row, col) to position object {x, y}
function getPosition(row, col) {
  if (row < 0 || row >= gridRows || col < 0 || col >= gridCols) {
    return null;
  }
  const offsetX = (row % 2 === 0) ? 0 : TILE_WIDTH / 2;
  return {
    x: col * TILE_WIDTH + offsetX,
    y: row * TILE_HEIGHT
  };
}

// Place jumper centered on the tile (accounting for jumper size offsets)
function placeJumper(row, col) {
  const pos = getPosition(row, col);
  if (!pos) return;
  jumper.style.transform = `translate(${pos.x + jumperOffsetX}px, ${pos.y + jumperOffsetY}px)`;
}

// Initialize jumper in the middle of the grid
function initJumper() {
  calculateGrid();
  currentRow = Math.floor(gridRows / 2);
  currentCol = Math.floor(gridCols / 2);
  placeJumper(currentRow, currentCol);
  jumper.style.transition = 'transform 0.3s ease-out';
}

function getNeighbors(row, col) {

  
  const neighbors = [];

  // Up-left and up-right
  if (row > 0) {
    if (row % 2 === 0) {
      // even row
      neighbors.push({ row: row - 1, col: col - 1 });
      neighbors.push({ row: row - 1, col: col });
    } else {
      // odd row
      neighbors.push({ row: row - 1, col: col });
      neighbors.push({ row: row - 1, col: col + 1 });
    }
  }

  // Down-left and down-right
  if (row < gridRows - 1) {
    if (row % 2 === 0) {
      neighbors.push({ row: row + 1, col: col - 1 });
      neighbors.push({ row: row + 1, col: col });
    } else {
      neighbors.push({ row: row + 1, col: col });
      neighbors.push({ row: row + 1, col: col + 1 });
    }
  }

  // Filter out invalid neighbors (out of bounds cols)
  return neighbors.filter(n => n.col >= 0 && n.col < gridCols);
}

// Jump only to a random neighboring tile
function jumpToNeighbor() {
  const neighbors = getNeighbors(currentRow, currentCol);
  if (neighbors.length === 0) return; // no moves possible

  const next = neighbors[Math.floor(Math.random() * neighbors.length)];

  currentRow = next.row;
  currentCol = next.col;
  placeJumper(currentRow, currentCol);
}

window.addEventListener('load', () => {
  initJumper();
  setInterval(jumpToNeighbor, 1000);
});

window.addEventListener('resize', () => {
  initJumper();
});
