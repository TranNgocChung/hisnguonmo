#region License

// Created by phuongdt

#endregion

using Inventec.Desktop.Core.Specifications;

namespace Inventec.Desktop.Core.Actions
{
    /// <summary>
    /// Associates authority tokens with an action.
    /// </summary>
    /// <remarks>
    /// This attribute sets the action permissibility via the <see cref="Action.SetPermissibility(ISpecification)"/> method.
    /// If multiple authority tokens are supplied in an array to a single instance of the attribute, those tokens will be combined using AND.  If
    /// multiple instances of this attribute are specified, the tokens associated with each instance are combined
    /// using OR logic.  This allows for the possibility of constructing a permission specification based on a complex boolean
    /// combination of authority tokens.
    /// </remarks>
    public class ActionPermissionAttribute : ActionDecoratorAttribute
    {
        private string[] _authorityTokens;

        /// <summary>
        /// Constructor - the specified authority token will be associated with the specified action ID.
        /// </summary>
        public ActionPermissionAttribute(string actionID, string authorityToken)
            : this(actionID, new string[] { authorityToken })
        {
        }

        /// <summary>
        /// Constructor - all of the specified tokens will combined using AND and associated with the specified action ID.
        /// </summary>
        public ActionPermissionAttribute(string actionID, params string[] authorityTokens)
            :base(actionID)
        {
            _authorityTokens = authorityTokens;
        }

		/// <summary>
		/// Applies permissions represented by this attribute to an action instance, via the specified <see cref="IActionBuildingContext"/>.
		/// </summary>
		public override void Apply(IActionBuildingContext builder)
        {
            // if this is the first occurence of this attribute, create the parent spec
            if (builder.Action.PermissionSpecification == null)
                builder.Action.PermissionSpecification = new OrSpecification();

            // combine the specified tokens with AND logic
            AndSpecification and = new AndSpecification();
            //foreach (string token in _authorityTokens)
            //{
            //    and.Add(new PrincipalPermissionSpecification(token));
            //}

            // combine this spec with any previous occurence of this attribute using OR logic
            ((OrSpecification)builder.Action.PermissionSpecification).Add(and);
        }
    }
}
