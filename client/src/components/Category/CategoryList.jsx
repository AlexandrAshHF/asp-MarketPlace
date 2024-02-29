import React, { useEffect, useState } from "react";
import CategoryItem from './CategoryItem';
import classes from './styles/CategoryList.module.css';

function CategoryList({isVisable, categories, ...props}) {
    const duplicate = categories;
    const [selected, setSelected] = useState(null);
    const [current, setCurrent] = useState(categories);

    useEffect(() => {
        setCurrent(duplicate.filter(x => x.id === selected.id));
    }, [selected])

    return(
        (isVisable && 
            <div {...props} className={classes.categoryBlock}>

                <label style={{fontSize: 'large', fontWeight: 'bold'}}>
                    {selected != null ? selected.title : 'Categories'}
                </label>

                {current.map((item) => (
                    <CategoryItem category={item.title} onClick={() => setSelected(item)}/>
                ))}

            </div>
        )
    );
}

export default CategoryList;