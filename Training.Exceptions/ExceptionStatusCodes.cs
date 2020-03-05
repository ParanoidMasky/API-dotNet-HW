using System;
using System.Collections.Generic;
using System.Net;
using Training.Exceptions;

namespace Training.Exceptions
{
    public class ExceptionStatusCodes
    {
        public static Dictionary<Type, HttpStatusCode> Map = new Dictionary<Type, HttpStatusCode>()
        {
            {typeof(BadRequestException), HttpStatusCode.BadRequest},
            {typeof(NotAuthorizedException), HttpStatusCode.Forbidden},
            {typeof(ObjectDoesNotExistException), HttpStatusCode.NotFound},
            {typeof(DuplicateException), HttpStatusCode.Conflict},
            {typeof(PreconditionFailedException), HttpStatusCode.PreconditionFailed},
            {typeof(ExpectationFailedException), HttpStatusCode.ExpectationFailed},
            {typeof(InvalidCredentialsException), HttpStatusCode.Unauthorized}
        };
    }
}
