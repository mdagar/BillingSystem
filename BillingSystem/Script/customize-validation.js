
// CR--893 | RISHI PANDEY | 11 Dec 2015

function Validate(containerId) {
    var errorHtml = "PLEASE RESOLVE BELOW MENTIONED ERRORS \n";
    var labelText = "";
    var errorInput = $(containerId).find(".errorRedBox");
    errorInput.removeClass("errorRedBox");

    var hasError = false;
    debugger;
    //===========Required Field Validator==============
    var validate = containerId + " .requiredField";
    $(validate).each(function () {
        if (!checkHiddenFields($(this))) {
            if (jQuery.trim($(this).val()) == '') {
                labelText = $(this).attr('title');
                $(this).addClass("errorRedBox");
                errorHtml += "--" + labelText + " is Mandatory.\n";
                hasError = true;
            }
        }
    });

    //===========Required Auto Complete Kendo UI Field Validator==============
    var validateAutoComplete = containerId + " .requiredAutoCompleteField";
    $(validateAutoComplete).each(function () {
        if (!checkHiddenFields($(this))) {
            if (jQuery.trim($(this).val()) == '') {
                labelText = $(this).attr('title');
                $(this).addClass("errorRedBox");
                errorHtml += "--" + labelText + " is Mandatory.\n";
                hasError = true;
            }
        }
    });

    //===========Required Field Validator==============
    var validateDate = containerId + " .dateValidateField";
    $(validateDate).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var dtRegex = /[1-9\-]{4}[0-9\-]{2}[0-9\-]{2}/;
                if (!dtRegex.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Name===================
    var validateName = containerId + " .name";
    $(validateName).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var nameReg = /^[a-zA-Z]+$/;
                if (!nameReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Full Name===================
    var validateFullName = containerId + " .fullName";
    $(validateFullName).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var fullNameReg = /^[a-zA-Z ]+$/;
                if (!fullNameReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Charactor And Nombers Only===================
    var validateGeneral = containerId + " .general";
    $(validateGeneral).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var generalReg = /^[a-zA-Z0-9 .(),\/%&=\$#@!?_:;-]+$/;
                if (!generalReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + labelText + " Cannot contain Special Characters (<,>,:,',+,^).\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Contact Number===================
    var validateContact = containerId + " .contact";
    $(validateContact).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var contactReg = /^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$/;
                if (!contactReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Phone Number===================
    var validatePhoneNumber = containerId + " .phoneNumber";
    $(validatePhoneNumber).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var contactReg = /^([0-9]{4}[\-]{1}[0-9]{7})$/;
                if (!contactReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Only Numeric===================
    var validateNumericValue = containerId + " .numericValue";
    $(validateNumericValue).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var numericValueReg = /^[0-9]+$/;
                if (!numericValueReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Only Decimal Values===================
    var validateDecimalValue = containerId + " .decimalValue";
    $(validateDecimalValue).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var decimalValueReg = /^\d+(\.\d{1,2})?$/;
                if (!decimalValueReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });
    
    //===========Validate Email Address===================
    var validateEmail = containerId + " .email";
    $(validateEmail).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
                if (!emailReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Email Address===================
    var validateMultipleEmail = containerId + " .multipleEmail";
    $(validateMultipleEmail).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var emailReg = /^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;,.]{0,1}\s*)+$/;
                if (!emailReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Address===================
    var validateAddress = containerId + " .address";
    $(validateAddress).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var addressReg = /^[a-zA-Z0-9 .\/(),-]+$/;
                if (!addressReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Web Address===================
    var validateUrl = containerId + " .webUrl";
    $(validateUrl).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var urlReg = /^(www\.)[A-Za-z0-9_-]+\.+[A-Za-z0-9.\/%&=\?_:;-]+$/;
                if (!urlReg.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--" + "Invalid " + labelText + ".\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Validate Select Input===================
    var validateDdlSelectedItem = containerId + " .ddlSelectedItem";
    $(validateDdlSelectedItem).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() <= 0 || $(this).val() == "") {
                labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                errorHtml += "--" + labelText + " is Mandatory.\n";
                hasError = true;
            }
        }
    });

    //===========Validate Select Input===================
    var validateSelectedItem = containerId + " .ddlSelectedItemTitleAndGender";
    $(validateSelectedItem).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() <= 0 || $(this).val() == "") {
                labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                errorHtml += "--" + labelText + " is Mandatory.\n";
                hasError = true;
            }
        }
    });

    //===========Validate Minimum Length===================
    var validateMinLength = containerId + " .minLength";
    $(validateMinLength).each(function () {
        if (!checkHiddenFields($(this))) {
            var minT = $(this).attr("minLength");
            if ($(this).val().length < parseInt(minT)) {
                $(this).addClass("errorRedBox");
                errorHtml += "--" + "Minimum " + minT + " characters are allowed!\n";
                hasError = true;
            }
        }
    });

    //===========Validate Maximum Length===================
    var validateMaxLength = containerId + " .maxLength";
    $(validateMaxLength).each(function () {
        if (!checkHiddenFields($(this))) {
            var maxT = $(this).attr("maxLength");
            if ($(this).val().length > parseInt(maxT)) {
                errorHtml += "--" + "Maximum " + maxT + " characters are allowed!\n";
                $(this).addClass("errorRedBox");
                hasError = true;
            }
        }
    });
    //===========Check Password Policy Field Validator==============
    var validatePassPolicy = containerId + " .passValidateField";
    $(validatePassPolicy).each(function () {
        if (!checkHiddenFields($(this))) {
            if ($(this).val() != '') {
                var pwdRegex = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,20}$/;
                if (!pwdRegex.test(jQuery.trim($(this).val()))) {
                    labelText = $(this).attr('title'); $(this).addClass("errorRedBox");
                    errorHtml += "--Please use password policy.\n";
                    hasError = true;
                }
            }
        }
    });

    //===========Compare Field Validator==============
    var validateComparePass = containerId + " .compareTextField";
    var realValue = "";
    var rlCount = 0;
    $(validateComparePass).each(function () {
        if (rlCount == 0) {
            realValue = jQuery.trim($(this).val());
            rlCount++;
        }
        if (jQuery.trim($(this).val()) != realValue) {
            labelText = $(this).attr('title');
            errorHtml += "--Password not matched.\n";
            hasError = true;
        }
    });
   
    //===========Required MultipleText Validator==============
    var requiredMultipleTextField = containerId + " .requiredMultipleTextField";
    var errorMessage = "";
    $(requiredMultipleTextField).each(function () {
        if (!checkHiddenFields($(this))) {
            if (jQuery.trim($(this).val()) == '') {
                labelText = $(this).attr('title');
                $(this).addClass("errorRedBox");
                errorMessage = "--Please fill mandatory fields in secondary contact details.\n";
                hasError = true;
            }
        }
    });
    errorHtml += errorMessage;


    if (hasError) {
        alert(errorHtml);
    }
    return hasError;
}

function checkHiddenFields(input) {
    if ($(input).hasClass('hide')) {
        return true;

    }
    else {
        return false;
    }
}