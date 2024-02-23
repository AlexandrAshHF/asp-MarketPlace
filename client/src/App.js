import React from 'react';
import LoginForm from './components/User/Login/LoginForm';

function App() {
  return (
    <div className="App">
      <LoginForm errorMessege={"error"}/>
    </div>
  );
}

export default App;