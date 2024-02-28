import React from "react";
import classes from './styles/SearchInput.module.css'

const SearchInput = ({...props}) => {
    return (
        <input className={classes.searchLine} {...props}></input>
    );
}

export default SearchInput;