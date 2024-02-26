import React, { useState } from "react";
import CategoryItem from './CategoryItem';
import classes from './styles/CategoryList.module.css';

function CategoryList({visability, ...props}) {
    const [isVisable, setVisable] = useState(visability);

    return(
        (isVisable && 
            <div {...props} className={classes.categoryBlock}>
                <label style={{fontSize: 'large', fontWeight: 'bold'}}>Categories</label>
                {categories.map((item) => (
                    <CategoryItem category={item}/>
                ))}
            </div>)
    );
}

export default CategoryList;