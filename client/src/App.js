import React from 'react';
import ProductList from './components/Product/ProductList';

function App() {
  const arr = [
    {Id:"123456789", Title:"Title1", TypeName:"TypeName1", Price:3.14, ImageLink:"a"},
    {Id:"381983838", Title:"Title2", TypeName:"TypeName2", Price:12.14, ImageLink:"a"},
    {Id:"803810001", Title:"Title3", TypeName:"TypeName3", Price:500, ImageLink:"a"},
    {Id:"574832222", Title:"Title4TitleTitle", TypeName:"TypeName112344", Price:3.14, ImageLink:"a"}
  ]
  return (
    <div className="App">
      <ProductList list={arr}/>
    </div>
  );
}

export default App;