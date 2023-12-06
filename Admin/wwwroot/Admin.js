



    let pendingChanges = [];

    function openFeatureDetailsModal(featureId) {
        fetch(`/AdminM/FeatureDetails?featureId=${featureId}`)
            .then(response => response.text())
            .then(data => {
                $('#featureDetailsModalContent').html(data);
                $('#featureDetailsModal').modal('show');
            })
            .catch(error => {
                console.error('There was a problem with the fetch operation:', error);
            });
    }

    // Remove the closeFeatureDetailsPopup function as it is not needed for Bootstrap modal.


function closeFeatureDetailsPopup() {

        $('#featureDetailsPopup').hide();
        $('#featureDetailsPopupContent').empty(); // Clear the content when hiding
    }


    function closeFeatureDetailsModal() {
        $('#featureDetailsModal').modal('hide');
    }



    function closeFeaturePreviewModal() {
        $('#previewModal').modal('hide');
    }





























    function sortColumn(columnIndex) {
        var table = document.getElementById('featuresTable');
        var tbody = table.querySelector('tbody');
        var rows = Array.from(tbody.querySelectorAll('tr'));

        var isAscending = table.getAttribute('data-sort-order') === 'asc';

        rows.sort(function (a, b) {
            var aValue = a.cells[columnIndex].textContent.trim();
            var bValue = b.cells[columnIndex].textContent.trim();

            if (columnIndex === 1 || columnIndex === 4) {
                aValue = parseInt(aValue);
                bValue = parseInt(bValue);
            } //else if (columnIndex === 3) {
            //    aValue = parseFloat(aValue);
            //bValue = parseFloat(bValue);
            //        }

            var comparison = aValue > bValue ? 1 : -1;
            return isAscending ? comparison : -comparison;
        });

        rows.forEach(function (row) {
            tbody.appendChild(row);
        });

        // Toggle sort order
        var sortOrder = isAscending ? 'desc' : 'asc';
        table.setAttribute('data-sort-order', sortOrder);

        // Update sort icons
        updateSortIcons(columnIndex, sortOrder);
    }

    function updateSortIcons(columnIndex, sortOrder) {
        var sortIcons = document.querySelectorAll('.sort-icon');
        sortIcons.forEach(function (icon) {
            icon.className = 'fas fa-sort';
        });

        var iconId = `sortIcon${columnIndex}`;
        var targetIcon = document.getElementById(iconId);
        targetIcon.className = sortOrder === 'asc' ? 'fas fa-sort-up' : 'fas fa-sort-down';
    }






    // Function to display the confirmation modal
function showConfirmation() {
  document.getElementById("confirmationModal").style.display = "block";
}

// Function to close the confirmation modal
function closeConfirmation() {
  document.getElementById("confirmationModal").style.display = "none";
}

// Function to perform the confirmed action
function confirmAction() {
  // Add your action logic here
  // For example:
  alert("Confirmed!");
  closeConfirmation();
}































    function updateStatus(featureId, newStatus) {
        // Make an asynchronous call to the server to update the status
        fetch(`/AdminM/UpdateStatus?featureId=${featureId}&newStatus=${newStatus}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                // Handle success, e.g., refresh the page or update UI
                location.reload();
            })
            .catch(error => {
                // Handle errors
                console.error('There was a problem with the fetch operation:', error);
            });
    }

function addChange(featureId, action, comment = '') {
    console.log('Pending Changes:', pendingChanges);
    if (pendingChanges.length < 4) {
        const existingChangeIndex = pendingChanges.findIndex(
            (change) => change.featureId === featureId
        );

        if (existingChangeIndex !== -1) {
            // Check if the action has changed
            if (pendingChanges[existingChangeIndex].action !== action) {
                // Update the existing change
                pendingChanges[existingChangeIndex].action = action;
                pendingChanges[existingChangeIndex].comment = comment;
            }
        } else {
            // Add a new change
            pendingChanges.push({ featureId, action, comment });
        }

        // Update the pending changes preview in the modal without calling another function
        var previewContent = '<h5>Changes Preview:</h5><ul>';
        pendingChanges.forEach((change) => {
            previewContent += `<li>${change.action} for feature ID ${change.featureId}</li>`;
        });
        previewContent += '</ul>';

        var previewBody = document.getElementById('previewChangesBody');
        if (previewBody) {
            previewBody.innerHTML = previewContent;
        }
    } else {
        // Show an alert indicating that no more changes can be added
        alert('Maximum number of changes reached. Cannot add more.');

        // Redo the last change (remove the last entry)
        pendingChanges.pop();

        // Update the pending changes preview in the modal without calling another function
        var previewContent = '<h5>Changes Preview:</h5><ul>';
        pendingChanges.forEach((change) => {
            previewContent += `<li>${change.action} for feature ID ${change.featureId}</li>`;
        });
        previewContent += '</ul>';

        var previewBody = document.getElementById('previewChangesBody');
        if (previewBody) {
            previewBody.innerHTML = previewContent;
        }
    }
}



    function saveComment(featureId) {
        var featureId = document.getElementById("hiddenFeatureId").value;
        var comment = document.getElementById("commentTextArea").value;
        console.log(comment + "wed");
        var confirmation = window.confirm("Are you sure you want to add this comment?");
        if (confirmation) {



            fetch(`/AdminM/UpdateComment?featureId=${featureId}&comment=${comment}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                }
            })

                .then(response => {
                    if (response.ok) {
                        // console.log('Comment accepted successfully');
                        addChange(featureId, 'Comment', comment);
                        $('#commentModal').modal('hide');
                    } else {
                        console.error('Failed to Comment feature');
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                });



        }
    }














    function acceptFeature(featureId) {
        var acceptButton = document.querySelector(`button[data-feature-id="${featureId}"][onclick^="acceptFeature"]`);
        var rejectButton = document.querySelector(`button[data-feature-id="${featureId}"][onclick^="rejectFeature"]`);

        var confirmation = window.confirm("Are you sure you want to accept the feature?");
        if (confirmation) {
            if (acceptButton && acceptButton.innerText !== 'Approved') {
                acceptButton.innerText = 'Approved';
                acceptButton.classList.add('btn-success');
                acceptButton.classList.remove('btn-primary');
            }

            if (rejectButton && rejectButton.innerText !== 'Reject') {
                rejectButton.innerText = 'Reject';
                rejectButton.classList.remove('d-none');
                rejectButton.classList.remove('btn-danger');
                rejectButton.classList.add('btn-primary');
            }

            fetch(`/AdminM/AcceptFeature?featureId=${featureId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => {
                    if (response.ok) {
                        console.log('Feature accepted successfully');
                        addChange(featureId, 'Accept');
                    } else {
                        console.error('Failed to accept feature');
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        }
    }

    function rejectFeature(featureId) {
        var acceptButton = document.querySelector(`button[data-feature-id="${featureId}"][onclick^="acceptFeature"]`);
        var rejectButton = document.querySelector(`button[data-feature-id="${featureId}"][onclick^="rejectFeature"]`);

        console.log("else if reject");
        var confirmation = window.confirm("Are you sure you want to reject the feature?");

        if (confirmation) {
            if (rejectButton && rejectButton.innerText !== 'Rejected') {
                rejectButton.innerText = 'Rejected';
                rejectButton.classList.add('btn-danger');
                rejectButton.classList.remove('btn-primary');
                //act = "Reject";
            }

            if (acceptButton && acceptButton.innerText !== 'Accept') {
                acceptButton.innerText = 'Accept';
                acceptButton.classList.remove('btn-success');
                acceptButton.classList.add('btn-primary');
            }


            fetch(`/AdminM/RejectFeature?featureId=${featureId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => {
                    if (response.ok) {
                        console.log('Feature rejected successfully');
                        addChange(featureId, 'Reject');
                        act = null;
                    } else {
                        console.error('Failed to reject feature');
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        }
    }






    function triggerAddChange(featureId, action, comment) {
        // Here you can handle both action and comment as needed
        addChange(featureId, action, comment);
    }


    function updateAllChanges() {
        // Create a preview of changes
        var previewContent = '<h5>Changes Preview:</h5><ul>';
        pendingChanges.forEach(change => {
            previewContent += `<li>${change.action} for feature ID ${change.featureId}</li>`;
        });
        previewContent += '</ul>';

        // Set the preview content inside the modal body
        var previewBody = document.getElementById('previewChangesBody');
        if (previewBody) {
            previewBody.innerHTML = previewContent;
        }

        // Show the modal
        $('#previewModal').modal('show');

        // Handle the OK button click to proceed with updates
        $('#confirmUpdateButton').on('click', function () {
            // Assuming you want to send changes to the server using fetch
            fetch('/AdminM/UpdateAllChanges', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(pendingChanges)
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    // Handle success, e.g., clear changes or update UI to reflect changes
                    pendingChanges = []; // Clear changes after successful update
                    $('#previewModal').modal('hide'); // Close the modal
                    location.reload(); // Refresh the UI or handle as needed
                })
                .catch(error => {
                    // Handle errors
                    console.error('There was a problem with the fetch operation:', error);
                });
        });

        // Handle the Cancel button click to close the modal
        $('#cancelUpdateButton').on('click', function () {
            $('#previewModal').modal('hide'); // Close the modal
        });

        // Handle the "Clear All" button click to clear all changes and the preview content
        $('#clearAllChangesButton').on('click', function () {
            fetch('/AdminM/ClearPendingChanges', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    // Optional: Handle UI update or other tasks after clearing
                    console.log('Pending changes cleared successfully');
                })
                .catch(error => {
                    // Handle errors
                    console.error('There was a problem with the fetch operation:', error);
                });

            pendingChanges = []; // Clear pending changes
            $('#previewChangesBody').empty(); // Clear the preview content
            $('#previewModal').modal('hide'); // Close the modal
            location.reload(); // Refresh the page

        });
    }













    function openCommentBox(featureId) {
        // Set the featureId in a hidden field to use in saveComment
        document.getElementById("hiddenFeatureId").value = featureId;

        // Open the comment modal
        $('#commentModal').modal('show');
    }













    function closeCommentBox() {
        // Assuming you have a function to hide the comment modal
        $('#commentModal').modal('hide');
    }


    function downloadTableAsPDF() {
        const element = document.getElementById('featuresTable');

        // Clone the table element to avoid modifying the original
        const clonedTable = element.cloneNode(true);

        // Iterate over each row and remove the fifth and sixth columns
        clonedTable.querySelectorAll('tr').forEach(row => {
            row.removeChild(row.cells[5]); // Remove the fifth column (index 4)
            row.removeChild(row.cells[5]); // Remove the sixth column (index 4 again, as the previous removal shifted the indices)
        });

        // Specify options for html2pdf
        const options = {
            margin: 10,
            filename: 'features_table.pdf', // Default filename
            image: { type: 'jpeg', quality: 0.98 },
            html2canvas: { scale: 2 },
            jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' },
        };

        // Use html2pdf.js to generate the PDF and trigger the save dialog
        html2pdf(clonedTable, { ...options, output: 'save' });

    }
