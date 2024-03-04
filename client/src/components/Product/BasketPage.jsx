import React, { useEffect, useState } from "react";
import classes from './styles/BasketPage.module.css';
import ProductList from './ProductList';
import Select from "react-select/dist/declarations/src/Select";

function BasketPage() {
    const [places, setPlaces] = useState([]);
    const [selectedPlace, setSelectedPlace] = useState(null);
    const [productsList, setProducts] = useState([]);

    async function fetchPlace()
    {
        let response = await fetch('https://localhost:7004/Places/PlacesList', 
        {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        })
    }

    useEffect(() => {

    }, [])

    return(
        <div className={classes.mainBlock}>
            <Select options={places} isSearchable onChange={(value) => setSelectedPlace(value)}/>
            <ProductList products={productsList}/>
        </div>
    );
}

export default BasketPage;