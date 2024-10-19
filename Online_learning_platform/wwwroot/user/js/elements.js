// Copy button in lesson page 

function copyCode() {
    var code = document.getElementById("codeSnippet");
    
    var tempInput = document.createElement("textarea");
    tempInput.value = code.textContent;
    document.body.appendChild(tempInput);
    tempInput.select();
    document.execCommand("copy");
    document.body.removeChild(tempInput);
    
    var button = document.getElementById("copyButton");
    
    button.style.color = 'var(--main-color)';
    button.style.backgroundColor = ' var(--second-color)';
    alert("Copied");      
}

// ==========================

// Dropdown menu with icon  

document.addEventListener('DOMContentLoaded', function() {
    const dropdownIcon = document.getElementById('accountDropdown');
    const dropdownMenu = document.getElementById('dropdownMenu');

    // display of the dropdown menu on icon click
    dropdownIcon.addEventListener('click', function(event) {
        event.stopPropagation(); // Prevent click from bubbling up
        dropdownMenu.style.display = dropdownMenu.style.display === 'block' ? 'none' : 'block';
    });

    // Close the dropdown if clicking outside of it
    document.addEventListener('click', function(event) {
        if (!dropdownIcon.contains(event.target)) {
            dropdownMenu.style.display = 'none';
        }
    });
});


