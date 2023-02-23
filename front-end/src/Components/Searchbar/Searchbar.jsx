import React, { useEffect, useState } from "react";
import { useMousePosition } from "../../Custom/useMousePosition";
import './Searchbar.css'
import {useForm} from 'react-hook-form'

function Searchbar() {
  const {register, handleSubmit} = useForm();
  const mousePos = useMousePosition()
  const [showAnimation, setShowAnimation] = useState(false);
  const animation = () => {
    if(mousePos.y < 50){
      setShowAnimation(true)
    }
  }
  const onSubmitHandler = (data) => {
    console.log(data);
  }

  return (
    <form className="search" onSubmit={handleSubmit(onSubmitHandler)}>
      <input onFocus={() => animation()} className={showAnimation ? 'showAnimation' : 'hideAnimation'} type="search" placeholder="Search" {...register('search')}/>
    </form>
  );
}

export default Searchbar;
