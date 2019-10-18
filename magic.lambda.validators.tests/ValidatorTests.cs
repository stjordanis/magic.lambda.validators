/*
 * Magic, Copyright(c) Thomas Hansen 2019, thomas@gaiasoul.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using Xunit;
using magic.node;

namespace magic.lambda.validators.tests
{
    public class ValidatorTests
    {
        [Fact]
        public void VerifyEmail()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo@bar.com");
            signaler.Signal("validators.email", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyEmail_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo@@bar.com");
            signaler.Signal("validators.email", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyInteger()
        {
            var signaler = Common.Initialize();
            var args = new Node("", 5, new Node[] { new Node("min", 4), new Node("max", 7) });
            signaler.Signal("validators.integer", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyInteger_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", 8, new Node[] { new Node("min", 4), new Node("max", 7) });
            signaler.Signal("validators.integer", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyUrl()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "http://foo.com");
            signaler.Signal("validators.url", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyHttpsUrl()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "https://foo.com");
            signaler.Signal("validators.url", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyUrl_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo.com");
            signaler.Signal("validators.url", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyDate()
        {
            var signaler = Common.Initialize();
            var args = new Node("", DateTime.Now, new Node[] { new Node("min", DateTime.Now.AddSeconds(-5)), new Node("max", DateTime.Now.AddSeconds(5)) });
            signaler.Signal("validators.date", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyDate_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", DateTime.Now.AddSeconds(10), new Node[] { new Node("min", DateTime.Now.AddSeconds(-5)), new Node("max", DateTime.Now.AddSeconds(5)) });
            signaler.Signal("validators.date", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyEnum()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo", new Node[] { new Node("", "foo"), new Node("", "bar") });
            signaler.Signal("validators.enum", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyEnum_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo1", new Node[] { new Node("", "foo"), new Node("", "bar") });
            signaler.Signal("validators.enum", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyMandatory()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo");
            signaler.Signal("validators.mandatory", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyMandator_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("");
            signaler.Signal("validators.mandatory", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyRegEx()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo", new Node[] { new Node("regex", "^foo$") });
            signaler.Signal("validators.regex", args);
            Assert.Null(args.Value);
            Assert.Empty(args.Children);
        }

        [Fact]
        public void VerifyRegEx_FAILS()
        {
            var signaler = Common.Initialize();
            var args = new Node("", "foo_XXX", new Node[] { new Node("regex", "^foo$") });
            signaler.Signal("validators.regex", args);
            Assert.NotNull(args.Value);
            Assert.True(args.Value.GetType() == typeof(string));
            Assert.Empty(args.Children);
        }
    }
}
