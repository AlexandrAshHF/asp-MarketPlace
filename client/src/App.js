import React from 'react';
import AppRouter from './AppRouter';
import classes from './App.module.css'
import { BrowserRouter } from 'react-router-dom';
import NavigationBar from './components/Common/NavigationBar';

function App() {

  return (
    <BrowserRouter>
      <NavigationBar/>
      <div className={classes.App}>
        <AppRouter/>
      </div>
    </BrowserRouter>
  );
}

export default App;