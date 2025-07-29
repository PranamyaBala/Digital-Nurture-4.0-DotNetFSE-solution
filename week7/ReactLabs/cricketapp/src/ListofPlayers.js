function ListofPlayers({ players }) {
  return (
    <ul>
      {players.map((player, index) => (
        <li key={index}>
          Mr. {player.name} — <span>{player.score}</span>
        </li>
      ))}
    </ul>
  );
}

export default ListofPlayers;
