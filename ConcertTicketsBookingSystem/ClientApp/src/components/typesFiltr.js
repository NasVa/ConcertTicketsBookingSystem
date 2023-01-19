import React, { useState } from 'react';

import ToggleButton from 'react-bootstrap/ToggleButton';
import ToggleButtonGroup from 'react-bootstrap/ToggleButtonGroup';

export default function TypesFiltr(props){

    const [activeType, setActiveType]  = useState('');
    const categories = ['All', 'Classic', 'Party', 'OpenAir']

    const onClickType = (_activeType) =>{
        setActiveType(_activeType)
        console.log(_activeType)
        props.setType(categories[_activeType])
    }

    return(
        <div className="typesFiltr">
            <ToggleButtonGroup type="checkbox"  value={activeType}>
                {categories.map((category, i) => (
                <ToggleButton id="tbg-btn-{i}" value={category} onClick = {() => onClickType(i)}>
                    {category}
                </ToggleButton>
                ))}
            </ToggleButtonGroup>
        </div>
    )
}

