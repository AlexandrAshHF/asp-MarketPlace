import LoginForm from './components/User/LoginForm';
import RegistrationForm from './components/User/RegistrationForm';
import Profile from './components/User/Profile';
import ProductList from './components/Product/ProductList';
import SelectedProduct from './components/Product/SelectedProduct';

const Links = [
    {path:'/', component: ProductList, exact: true},
    {path:'Account/Login', component: LoginForm, exact: true},
    {path:'Account/Registration', component: RegistrationForm, exact: true},
    {path:'Account/Profile', component: Profile, exact: true},
    {path:'Products/ProductList', component: ProductList, exact: true},
    {path:'Products/SelectedProduct', component: SelectedProduct, exact: true}
];

export default Links;