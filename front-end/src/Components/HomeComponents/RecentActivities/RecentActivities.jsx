import React from 'react'
import Card from "../../Card/Card";
import './RecentActivities.css'

function RecentActivities() {
  const arr = [
    { name: "ch1", status: "live", nameOrg: "org1" },
    { name: "ch2", status: "live", nameOrg: "org1" },
    { name: "ch3", status: "live", nameOrg: "org1" },
    { name: "ch4", status: "live", nameOrg: "org1" },
    { name: "ch5", status: "live", nameOrg: "org1" },
    { name: "ch6", status: "live", nameOrg: "org1" },
  ];
  return (
    <div className='recentactivities'>
      {arr.map((item) => {
        return (
          <Card card={item} />
        )
      })}

    </div>
  )
}

export default RecentActivities