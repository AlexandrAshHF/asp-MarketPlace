import React, { useEffect, useState } from "react";
import SearchInput from "../../../UI/Inputs/SearchInput";
import classes from './styles/DefaultNav.module.css'
import CategoryList from "../../Category/CategoryList";
import { useNavigate } from "react-router-dom";

function DefaultNavPanel({params}) {
    const [searchLine, setSearchLine] = useState('');
    const [isVisable, setVisable] = useState(false);
    const [categories, setCategories] = useState([]);
    const navigate = useNavigate();

    async function fetchCategories() {
        let response = await fetch('https://localhost:7004/Category/CategoryList', {
            method: 'GET',
            headers: 
            {
                'Content-Type': 'application/json'
            }
        });

        let data;
        if(response.ok)
            data = await response.json();   
        else
            console.log('BzzzzBZZZzzz');

        setCategories(data);
    }

    useEffect(() => {
        fetchCategories();
    }, [])

    const handleEnterDown = (event) => {
        if(event.key === 'Enter')
            console.log(searchLine);
    }

    const basketClick = () => navigate('Account/Basket', {replace:true});

    const profileClick = () => navigate('Account/Profile', {replace:true});

    return(
        <div className={classes.panelBlock}>

            <button className={classes.categoryButton}
             onClick={() => setVisable(!isVisable)} categories={categories}>
                <img alt="openCategory" src='/images/menu.png' className={classes.innerImg}/>
            </button>

            <SearchInput type='text' placeholder='Search'
             onChange={(e) => setSearchLine(e.target.value)}
             onKeyDown={handleEnterDown}/>

            <button className={classes.basketButton} onClick={basketClick}>
                <img alt="basket" src='/images/checkout.png' className={classes.innerImg}/>
            </button>

            <button className={classes.profileButton} onClick={profileClick}>
                <img alt="profile" src='/images/user.png' className={classes.innerImg}/>
            </button>

            <CategoryList isVisable={isVisable} categories={categories}/>

        </div>
    );
}

export default DefaultNavPanel;