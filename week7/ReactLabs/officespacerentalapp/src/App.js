import React from 'react';
import logo from './logo.svg';
import './App.css';
import officeImg from './office.webp';

function App() {
  const heading = "Office Space";
  const jsxatt = (
    <img
      src={officeImg}
      width="25%"
      height="25%"
      alt="Office Space"
    />
  );

  // Single object
  const ItemName = {
    Name: "DBS",
    Rent: 50000,
    Address: "Chennai",
  };

  // // List of office spaces
  // const officeSpaces = [
  //   { Name: "DBS", Rent: 50000, Address: "Chennai" },
  //   { Name: "Regus", Rent: 75000, Address: "Bangalore" },
  //   { Name: "SmartWorks", Rent: 60000, Address: "Hyderabad" },
  //   { Name: "WeWork", Rent: 85000, Address: "Mumbai" },
  // ];

  return (
    <div className="App">
      <h1>{heading}, at Affordable Range</h1>
      {jsxatt}

      <h2>Office Space:</h2>
      <h3>Name: {ItemName.Name}</h3>
      <h3 className={ItemName.Rent <= 60000 ? "textRed" : "textGreen"}>
        Rent: Rs. {ItemName.Rent}
      </h3>
      <h3>Address: {ItemName.Address}</h3>

      <hr />

      {/* <h2>All Office Spaces:</h2>
      {officeSpaces.map((item, index) => {
        const colorClass = item.Rent <= 60000 ? "textRed" : "textGreen";
        return (
          <div key={index}>
            <h3>Name: {item.Name}</h3>
            <h3 className={colorClass}>Rent: Rs. {item.Rent}</h3>
            <h3>Address: {item.Address}</h3>
            <hr />
          </div>
        );
      })} */}
    </div>
  );
}

export default App;
