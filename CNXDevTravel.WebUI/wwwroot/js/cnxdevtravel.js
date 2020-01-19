window.SubmitForm = (formId, name, profileimageurl, token) => {
    document.getElementById('name').value = name;
    document.getElementById('profileimageurl').value = profileimageurl;
    document.getElementById('token').value = token;
    var form = document.getElementById(formId);
    form.submit();
};