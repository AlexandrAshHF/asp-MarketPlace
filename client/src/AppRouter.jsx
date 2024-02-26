import React from "react";
import {Routes, Route} from 'react-router-dom';
import Links from './Router';

function AppRouter() {
    return(
        <Routes>
            {Links.map(route => {
                return(
                    <Route 
                    element={React.createElement(route.component)}
                    path={route.path}
                    exact={route.exact}
                    key={route.path}/>
                );
            })}
        </Routes>
    );
}

export default AppRouter;