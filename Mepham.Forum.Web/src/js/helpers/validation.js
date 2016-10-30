import React from 'react';

export function renderValidationErrors(validationErrors) {
    if (validationErrors == null) return null;
    return (
        <ul class="validation-errors">
            {
                Object.keys(validationErrors).map((property) => {
                    return <li key={property} class="text-warning">{validationErrors[property]}</li> 
                })
            }
        </ul>
    );
}