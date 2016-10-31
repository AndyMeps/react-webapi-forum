import React from 'react';

/**
 * Reusable function to return a formatted list of validation errors.
 *
 * @export
 * @param {any} validationErrors ASP.NET WebAPI ModelStateDictionary object.
 * @returns JSX
 */
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