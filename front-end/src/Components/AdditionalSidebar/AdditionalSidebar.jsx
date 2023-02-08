import React, { useState } from "react";
import Card from "../Card/Card";
import Searchbar from "../Searchbar/Searchbar";
import "./AdditionalSidebar.css";

function AdditionalSidebar() {
  return (
    <div className="additional">
        <Searchbar />
      <Card cards={[{ name: "ch1", status: "live", nameOrg: "org1" }]} />
    </div>
  );
}

export default AdditionalSidebar;
