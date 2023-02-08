import React, { useEffect, useState } from "react";
import './Searchbar.css'

function Searchbar() {
  const [search, setSearch] = useState("");
  const [mousePos, setMousePos] = useState({});
  const [showAnimation, setShowAnimation] = useState(false);



  useEffect(() => {
    const handleMouseMove = (event) => {
      setMousePos({ x: event.clientX, y: event.clientY });
    };

    window.addEventListener('mousemove', handleMouseMove);

    return () => {
      window.removeEventListener(
        'mousemove',
        handleMouseMove
      );
    };
  }, []);

  const animation = () => {
    if(mousePos.y < 50){
      setShowAnimation(true)
    }
  }

  return (
    <>
      <input onFocus={() => animation()} className={showAnimation ? 'showAnimation' : 'hideAnimation'} type="search" placeholder="Search" onChange={(x) => setSearch(x.target.value)}/>
    </>
  );
}

export default Searchbar;
