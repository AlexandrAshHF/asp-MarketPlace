import React, { useEffect } from "react";
import {Routes, Route, useNavigate} from 'react-router-dom';
import Links from './Router';

function AppRouter() {
    const navigate = useNavigate();

    useEffect(() => {
        navigate('/Login')
      }, []);

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