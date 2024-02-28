import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import DefaultNavPanel from "./NavPanels/DefaultNavPanel";

function NavigationBar() {
    const location = useLocation();
    const [navbar, setNavbar] = useState(null);

    useEffect(() => {

        if(location.pathname.includes('/Seller'))
            setNavbar(null);

        else if(location.pathname.includes('/Admin'))
            setNavbar(null);

        else if(location.pathname.includes('/Account'))
            setNavbar(null);

        else
            setNavbar(<DefaultNavPanel/>);

    }, [location])

    return navbar;
}

export default NavigationBar;