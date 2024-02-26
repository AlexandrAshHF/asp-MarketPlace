import React, { useState } from "react";
import SearchInput from "../../../UI/Inputs/SearchInput";
import classes from './styles/DefaultNav.module.css'

function DefaultNavPanel({params}) {
    const [searchLine, setSearchLine] = useState('');

    const handleEnterDown = (event) => {
        if(event.key === 'Enter')
            console.log(searchLine);
    }

    const basketClick = () => {
        console.log('basket click');
    }

    const profileClick = () => {
        console.log('profile click');
    }

    return(
        <div className={classes.panelBlock}>
            <button className={classes.categoryButton}>
                <img alt="openCategory"/>
            </button>
            <SearchInput type='text' placeholder='Search'
             onChange={(e) => setSearchLine(e.target.value)}
             onKeyDown={handleEnterDown}/>
            <button className={classes.basketButton} onClick={basketClick}>
                <img alt="basket"/>
            </button>
            <button className={classes.profileButton} onClick={profileClick}>
                <img alt="profile"/>
            </button>
        </div>
    );
}

export default DefaultNavPanel;