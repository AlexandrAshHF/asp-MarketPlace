import React from "react";
import classes from './styles/CategoryItem.module.css'

function CategoryItem({category, ...props}) {
    return(
        <button {...props} key={category.Id} className={classes.categoryItem}>
            <label>{category.Title}</label>
        </button>
    );
}

export default CategoryItem;