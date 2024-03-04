import React, { useEffect, useState } from "react";
import classes from './styles/BasketPage.module.css';
import ProductList from './ProductList';
import Select from "react-select";

function BasketPage() {
    const [places, setPlaces] = useState([]);
    const [selectedPlace, setSelectedPlace] = useState(null);

    async function fetchPlace()
    {
        let response = await fetch('https://localhost:7004/Places/PlacesList', 
        {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        });

        if(response.ok){
            let data = await response.json();
            let place = [ { value: "", label: `Choose place` } ];
            data.forEach(element => {
                place.push({ value: element.id, label: `${element.city}, ${element.address}` });
            });
            console.log(place);
            setPlaces(place);
        }
    }

    async function createOrder(){

    }

    useEffect(() => {
        fetchPlace();
    }, [])

    return(
        <div className={classes.mainBlock}>
            <Select options={places} isSearchable 
            onChange={(value) => setSelectedPlace(value)} className={classes.selectPlace}/>
            <ProductList isCatalog={false}/>
            <button>Checkout</button>
        </div>
    );
}

export default BasketPage;