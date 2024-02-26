import React from "react";
import classes from './styles/SearchInput.module.css'

const SearchInput = ({...props}) => {
    return (
        <input className={classes.searchLine} {...props}/>
    );
}

export default SearchInput;