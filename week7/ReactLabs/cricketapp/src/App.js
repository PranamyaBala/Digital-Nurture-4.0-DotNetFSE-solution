import logo from './logo.svg';
import './App.css';
import ListofPlayers from './ListofPlayers';
import Scorebelow70 from './Scorebelow70';
import { OddPlayers } from './OddPlayers';
import { EvenPlayers } from './EvenPlayers';
import ListOfIndianPlayers from './ListOfIndianPlayers';

function App() {
  const flag = true;
  const players = [
    { name: 'Jack', score: 50 },
    { name: 'Michael', score: 70 },
    { name: 'John', score: 40 },
    { name: 'Ann', score: 61 },
    { name: 'Elisabeth', score: 61 },
    { name: 'Sachin', score: 95 },
    { name: 'Dhoni', score: 100 },
    { name: 'Virat', score: 84 },
    { name: 'Jadeja', score: 64 },
    { name: 'Raina', score: 75 },
    { name: 'Rohit', score: 80 }
  ];

  const T20Players = ['Sachin', 'Dhoni', 'Virat'];
  const RanjiTrophyPlayers = ['Rohit', 'Yuvraj', 'Raina'];
  const IndianTeam = [...T20Players, ...RanjiTrophyPlayers];

  if (flag === false) {
    return (
      <div>
        <h1>List of Players</h1>
        <ListofPlayers players={players} />

        <hr />
        <h1>List of Players having Scores Less than 70</h1>
        <Scorebelow70 players={players} />
      </div>
    );
  } else {
    return (
      <div>
        <h1>Indian Team</h1>

        <h2>Odd Players</h2>
        {OddPlayers(IndianTeam)}

        <h2>Even Players</h2>
        {EvenPlayers(IndianTeam)}

        <hr />
        <h2>List of Indian Players Merged:</h2>
        <ListOfIndianPlayers players={IndianTeam} />
      </div>
    );
  }
}

export default App;