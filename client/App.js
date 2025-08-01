import React from 'react';
import CallNotification from './components/CallNotification';
import CustomerInfo from './components/CustomerInfo';
import VoiceControl from './components/VoiceControl';

function App() {
  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Customer Support Portal</h1>
      <CallNotification />
      <CustomerInfo />
      <VoiceControl />
    </div>
  );
}

export default App;
