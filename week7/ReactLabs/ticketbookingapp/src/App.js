import React, { useState } from 'react';

// Greeting components
function UserGreeting() {
  return <h2>Welcome Back! You can now book flight tickets.</h2>;
}

function GuestGreeting() {
  return <h2>Hello Guest! Please login to book flight tickets.</h2>;
}

// Login Button
function LoginButton(props) {
  return (
    <button onClick={props.onClick}>
      Login
    </button>
  );
}

// Logout Button
function LogoutButton(props) {
  return (
    <button onClick={props.onClick}>
      Logout
    </button>
  );
}

// Greeting handler
function Greeting(props) {
  const isLoggedIn = props.isLoggedIn;
  if (isLoggedIn) {
    return <UserGreeting />;
  }
  return <GuestGreeting />;
}

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLoginClick = () => setIsLoggedIn(true);
  const handleLogoutClick = () => setIsLoggedIn(false);

  return (
    <div style={{ textAlign: 'center', marginTop: '30px' }}>
      <h1>Flight Booking App</h1>

      {/* Greeting section */}
      <Greeting isLoggedIn={isLoggedIn} />

      {/* Show login or logout button */}
      {isLoggedIn ? (
        <LogoutButton onClick={handleLogoutClick} />
      ) : (
        <LoginButton onClick={handleLoginClick} />
      )}

      {/* Sample flight data for both users */}
      {/* <div style={{ marginTop: '20px' }}>
        <h3>Flight Details:</h3>
        <ul style={{ listStyle: 'none' }}>
          <li>✈ Air India - Delhi to Mumbai - ₹5000</li>
          <li>✈ Indigo - Bangalore to Chennai - ₹3500</li>
          <li>✈ Vistara - Kolkata to Hyderabad - ₹4500</li>
        </ul>
      </div> */}

      {/* Booking option for logged in users */}
      {/* {isLoggedIn && (
        <div style={{ marginTop: '20px', color: 'green' }}>
          <h3>Click on a flight to book now!</h3>
        </div>
      )} */}
    </div>
  );
}

export default App;
