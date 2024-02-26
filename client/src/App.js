import React from 'react';
import AppRouter from './AppRouter';
import { BrowserRouter } from 'react-router-dom';
import DefaultNavPanel from './components/Common/NavPanels/DefaultNavPanel'

function App() {

  return (
    <DefaultNavPanel/>
    // <BrowserRouter>
    //   <div className='App'>
    //     <AppRouter/>
    //   </div>
    // </BrowserRouter>
  );
}

export default App;