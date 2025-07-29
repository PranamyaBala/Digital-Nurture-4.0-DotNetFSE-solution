import React, { useState } from 'react';

function CurrencyConvertor() {
  const [rupees, setRupees] = useState('');
  const [euro, setEuro] = useState(null);

  const handleSubmit = () => {
    // Assume conversion rate: 1 Euro = 90 INR
    const converted = parseFloat(rupees) / 90;
    setEuro(converted.toFixed(2));
  };

  return (
    <div>
    <h2 style={{ color: 'green' }}>Currency Converter</h2>
      <input
        type="number"
        placeholder="Enter amount in INR"
        value={rupees}
        onChange={(e) => setRupees(e.target.value)}
      />
      <button onClick={handleSubmit}>Convert</button>

      {euro && (
        <h3>{rupees} INR = {euro} EUR</h3>
      )}
    </div>
  );
}

export default CurrencyConvertor;
