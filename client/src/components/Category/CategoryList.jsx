import React, { useEffect, useState } from "react";
import CategoryItem from './CategoryItem';
import classes from './styles/CategoryList.module.css';

function CategoryList({isVisable, categories, ...props}) {
    const [selected, setSelected] = useState(null);

    return(
        (isVisable && 
            <div {...props} className={classes.categoryBlock}>

                <label style={{fontSize: 'large', fontWeight: 'bold'}}>
                    {selected != null ? selected.title : 'Categories'}
                </label>

                {categories.map((item) => (
                    <CategoryItem category={item.title} onClick={() => setSelected(item)}/>
                ))}

            </div>)
    );
}

export default CategoryList;