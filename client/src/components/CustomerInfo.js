import React, { useState, useEffect } from 'react';
import axios from 'axios';

function CustomerInfo() {
  const [customer, setCustomer] = useState(null);

  useEffect(() => {
    axios.get('http://localhost:5000/api/customer/1234567890')
      .then(res => setCustomer(res.data))
      .catch(err => console.error(err));
  }, []);

  if (!customer) return <div>Loading customer data...</div>;

  return (
    <div className="mt-4 border p-4 rounded">
      <h2 className="font-bold text-lg">Customer Info</h2>
      <p><strong>Name:</strong> {customer.name}</p>
      <p><strong>Email:</strong> {customer.email}</p>
    </div>
  );
}

export default CustomerInfo;