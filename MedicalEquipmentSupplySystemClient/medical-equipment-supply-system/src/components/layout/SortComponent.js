import React, { useState } from "react";

const SortComponent = ({ onSortChange, sortOptions }) => {
    const [sortOrder, setSortOrder] = useState('asc');

    const handleSortChange = (e) => {
        const selectedKey = e.target.value;
        if (sortOrder === 'asc') {
            setSortOrder('desc');
        } else {
            setSortOrder('asc');
        }
        onSortChange(selectedKey, sortOrder);
    };

    return (
        <div>
            <select onChange={handleSortChange}>
                {sortOptions.map((option, index) => (
                    <option key={index} value={option.value}>{option.label}</option>
                ))}
            </select>
        </div>
    );
}

export default SortComponent;
