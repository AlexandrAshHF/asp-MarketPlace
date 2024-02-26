import LoginForm from './components/User/LoginForm';
import RegistrationForm from './components/User/RegistrationForm';
import Profile from './components/User/Profile';
import ProductList from './components/Product/ProductList';
import SelectedProduct from './components/Product/SelectedProduct';

const Links = [
    {path:'/', component: ProductList, exact: true},
    {path:'/Login', component: LoginForm, exact: true},
    {path:'/Registration', component: RegistrationForm, exact: true},
    {path:'/Profile', component: Profile, exact: true},
    {path:'/ProductList', component: ProductList, exact: true},
    {path:'/SelectedProduct', component: SelectedProduct, exact: true}
];

export default Links;