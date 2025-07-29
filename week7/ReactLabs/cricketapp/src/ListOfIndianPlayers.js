function ListOfIndianPlayers({ players }) {
  return (
    <ul>
      {players.map((name, index) => (
        <li key={index}>{name}</li>
      ))}
    </ul>
  );
}

export default ListOfIndianPlayers;
