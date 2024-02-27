import React from 'react';
import AppRouter from './AppRouter';
import classes from './App.module.css'
import { BrowserRouter } from 'react-router-dom';
import DefaultNavPanel from './components/Common/NavPanels/DefaultNavPanel'

function App() {

  return (
    <BrowserRouter>
      <DefaultNavPanel/>
      <div className={classes.App}>
        <AppRouter/>
      </div>
    </BrowserRouter>
  );
}

export default App;