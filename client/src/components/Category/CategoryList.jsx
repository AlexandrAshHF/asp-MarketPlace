import React, { useState } from "react";
import CategoryItem from './CategoryItem';
import classes from './styles/CategoryList.module.css';

function CategoryList({isVisable, categories, ...props}) {

    return(
        (isVisable && 
            <div {...props} className={classes.categoryBlock}>
                <label style={{fontSize: 'large', fontWeight: 'bold'}}>Categories</label>
                {categories.map((item) => (
                    <CategoryItem category={item.title}/>
                ))}
            </div>)
    );
}

export default CategoryList;